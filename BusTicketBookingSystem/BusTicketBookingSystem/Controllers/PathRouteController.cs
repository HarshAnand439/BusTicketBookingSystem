using BLL.DTOs;
using DAL.Data;
using DAL.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using BLL.Services;

namespace ServiceLayer.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PathRouteController : ControllerBase
    {
        private readonly IPathRouteService _pathRouteService;
        private readonly ILogger<PathRouteController> _logger;

        public PathRouteController(IPathRouteService pathRouteService, ILogger<PathRouteController> logger)
        {
            _pathRouteService = pathRouteService;
            _logger = logger;
        }

        [HttpGet("GetPathRoutes")]
        [ProducesResponseType(200, Type = typeof(IEnumerable<PathRoute>))]
        public IActionResult GetAllPathRoutes()
        {
            try
            {
                var PathRoutes = _pathRouteService.GetAllPathRoutes();
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }
                _logger.LogInformation("PathRoutes Fetched.");
                return Ok(PathRoutes);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occured while retrieving Pathroutes.");
                return StatusCode(500);
            }
        }

        [HttpGet("GetPathRouteById")]
        public IActionResult GetPathRouteById(int id)
        {
            try
            {
                var pathRoute = _pathRouteService.GetPathRouteById(id);
                if (pathRoute == null)
                {
                    return NotFound();
                }
                _logger.LogInformation("PathRoute is fetched by ID");
                return Ok(pathRoute);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred while retrieving a PathRoute by ID.");
                return StatusCode(500);
            }
        }

        [HttpPost("CreatePathRoute")]
        public IActionResult CreatePathRoute(PathRoute pathRoute)
        {
            try
            {
                if (pathRoute == null)
                {
                    return BadRequest(ModelState);
                }
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }
                if (!_pathRouteService.CreatePathRoute(pathRoute))
                {
                    ModelState.AddModelError("", "pathroute is not Created [CONTOLLER]");
                    return StatusCode(500, ModelState);
                }
                _logger.LogInformation("Pathroute is Created");
                return Ok("Pathroute Successfully Created");

                /*_pathRouteService.CreatePathRoute(pathRoute);

                return CreatedAtAction(nameof(GetPathRouteById), new { id = pathRoute.RouteId }, pathRoute);*/
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred while creating a pathroute.");
                return StatusCode(500);
            }
        }

        [HttpPut("UpdatePathRoute")]
        public IActionResult UpdatePathRoute(int id, PathRoute pathRoute)
        {
            try
            {
                if (id != pathRoute.RouteId)
                {
                    return BadRequest();
                }

                _pathRouteService.UpdatePathRoute(pathRoute);
                _logger.LogInformation("Pathroute is Created");

                return Ok("Pathroute Successfully Updated");
                /*if (pathRoute == null)
                {
                    return BadRequest(ModelState);
                }
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }
                if (!_pathRouteService.UpdatePathRoute(pathRoute))
                {
                    ModelState.AddModelError("", "pathroute is not Created [CONTOLLER]");
                    return StatusCode(500, ModelState);
                }
                _logger.LogInformation("Pathroute is Created");
                return Ok("Pathroute Successfully Created");*/
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred while updating a pathroute.");
                return StatusCode(500);
            }
        }

        [HttpDelete("DeletePathRoute")]
        public IActionResult DeletePathRoute(int id)
        {
            try
            {
                var pathRoute = _pathRouteService.GetPathRouteById(id);

                if (pathRoute == null)
                {
                    return NotFound();
                }
                _pathRouteService.DeletePathRoute(pathRoute);
                _logger.LogInformation("Pathroute is Deleted");

                return Ok("Pathroute Successfully Deleted");
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred while deleting a pathroute.");
                return StatusCode(500);
            }
        }
    }
}
