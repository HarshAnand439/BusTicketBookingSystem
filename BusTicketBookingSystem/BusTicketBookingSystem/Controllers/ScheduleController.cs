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

        public ScheduleController(IScheduleService scheduleService)
        {
            _scheduleService = scheduleService;
        }

        [HttpGet]
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
        }
    }
}
