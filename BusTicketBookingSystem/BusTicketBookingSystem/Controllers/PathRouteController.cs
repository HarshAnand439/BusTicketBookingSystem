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
        private readonly BLL.Services.IPathRouteService _pathRouteService;

        public PathRouteController(IPathRouteService pathRouteService)
        {
            _pathRouteService = pathRouteService;
        }

        [HttpGet]
        public IEnumerable<PathRoute> GetAllPathRoutes()
        {
            return _pathRouteService.GetAllPathRoutes();
        }

        [HttpGet("{id}")]
        public ActionResult<PathRoute> GetPathRouteById(int id)
        {
            var pathRoute = _pathRouteService.GetPathRouteById(id);

            if (pathRoute == null)
            {
                return NotFound();
            }

            return pathRoute;
        }

        [HttpPost]
        public ActionResult<PathRoute> CreatePathRoute(PathRoute pathRoute)
        {
            _pathRouteService.CreatePathRoute(pathRoute);

            return CreatedAtAction(nameof(GetPathRouteById), new { id = pathRoute.RouteId }, pathRoute);
        }

        [HttpPut("{id}")]
        public IActionResult UpdatePathRoute(int id, PathRoute pathRoute)
        {
            if (id != pathRoute.RouteId)
            {
                return BadRequest();
            }

            _pathRouteService.UpdatePathRoute(pathRoute);

            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult DeletePathRoute(int id)
        {
            var pathRoute = _pathRouteService.GetPathRouteById(id);

            if (pathRoute == null)
            {
                return NotFound();
            }

            _pathRouteService.DeletePathRoute(pathRoute);

            return NoContent();
        }
    }
}
