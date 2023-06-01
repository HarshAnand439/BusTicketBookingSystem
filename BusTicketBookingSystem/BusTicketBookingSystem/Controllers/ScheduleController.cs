using BLL.DTOs;
using BLL.Services;
using DAL.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ServiceLayer.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ScheduleController : ControllerBase
    {
        private readonly IScheduleService _scheduleService;
        private readonly ILogger<ScheduleController> _logger;

        public ScheduleController(IScheduleService scheduleService, ILogger<ScheduleController> logger)
        {
            _scheduleService = scheduleService;
            _logger = logger;
        }

        [HttpGet("GetSchedulees")]
        [ProducesResponseType(200, Type = typeof(IEnumerable<Schedule>))]
        public IActionResult GetAllSchedules()
        {
            try
            {
                var Schedulees = _scheduleService.GetAllSchedules();
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }
                _logger.LogInformation("Schedulees Fetched.");
                return Ok(Schedulees);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occured while retrieving Schedulees.");
                return StatusCode(500);
            }
        }

        [HttpGet("GetScheduleById")]
        public IActionResult GetScheduleById(int id)
        {
            try
            {
                var schedule = _scheduleService.GetScheduleById(id);
                if (schedule == null)
                {
                    return NotFound();
                }
                _logger.LogInformation("Schedule are fetched by ID");
                return Ok(schedule);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred while retrieving a Schedule by ID.");
                return StatusCode(500);
            }
        }

        [HttpPost("Create Schedule")]
        public IActionResult CreateSchedule(Schedule schedule)
        {
            try
            {
                /*if (schedule == null)
                {
                    return BadRequest(ModelState);
                }
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }
                if (!_scheduleService.CreateSchedule(schedule))
                {
                    ModelState.AddModelError("", "Schedule is not Created [CONTOLLER]");
                    return StatusCode(500, ModelState);
                }
                _logger.LogInformation("Schedule is Created");
                return Ok("Schedule Successfully Created");*/
                _scheduleService.CreateSchedule(schedule);
                return Ok("Schedule Successfully Created");
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred while creating a Schedule.");
                return StatusCode(500);
            }
        }

        [HttpPut("UpdateSchedule")]
        public IActionResult UpdateSchedule(int id, Schedule schedule)
        {
            try
            {
                if (id != schedule.ScheduleId)
                {
                    return BadRequest();
                }

                _scheduleService.UpdateSchedule(schedule);
                _logger.LogInformation("Schedule is Created");

                return Ok("Schedule Successfully Updated");
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred while updating a Schedule.");
                return StatusCode(500);
            }
        }

        [HttpDelete("DeleteSchedule")]
        public IActionResult DeleteSchedule(int id)
        {
            try
            {
                var schedule = _scheduleService.GetScheduleById(id);

                if (schedule == null)
                {
                    return NotFound();
                }
                _scheduleService.DeleteSchedule(schedule);
                _logger.LogInformation("Schedule is Deleted");

                return Ok("Schedule Successfully Deleted");
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred while deleting a Schedule.");
                return StatusCode(500);
            }
        }

        /*[HttpGet]
        public async Task<ActionResult<IEnumerable<Schedule>>> GetSchedules()
        {
            var schedules = await _scheduleService.GetAllSchedules();
            return Ok(schedules);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Schedule>> GetScheduleById(int id)
        {
            var schedule = await _scheduleService.GetScheduleById(id);

            if (schedule == null)
            {
                return NotFound();
            }

            return Ok(schedule);
        }

        [HttpPost]
        public async Task<ActionResult<Schedule>> CreateSchedule(Schedule schedule)
        {
            await _scheduleService.CreateSchedule(schedule);
            return CreatedAtAction(nameof(GetScheduleById), new { id = schedule.ScheduleId }, schedule);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateSchedule(int id, Schedule schedule)
        {
            if (id != schedule.ScheduleId)
            {
                return BadRequest();
            }

            var existingSchedule = await _scheduleService.GetScheduleById(id);

            if (existingSchedule == null)
            {
                return NotFound();
            }

            await _scheduleService.UpdateSchedule(schedule);

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteSchedule(int id)
        {
            var existingSchedule = await _scheduleService.GetScheduleById(id);

            if (existingSchedule == null)
            {
                return NotFound();
            }

            await _scheduleService.DeleteSchedule(id);

            return NoContent();
        }*/
    }
}
