using DAL.Data;
using DAL.Models;
using Microsoft.EntityFrameworkCore;

namespace DAL.Repository
{
    public class PathRouteRepository : IPathRouteRepository
    {
        private readonly AppDbContext _context;
        public PathRouteRepository(AppDbContext context)
        {
            _context = context;
        }

        public ICollection<PathRoute> GetAllPathRoutes()
        {
            return _context.PathRoutes.OrderBy(x => x.RouteId).ToList();
        }

        public PathRoute GetPathRouteById(int id)
        {
            return _context.PathRoutes.Where(x => x.RouteId == id).FirstOrDefault();
        }

        public PathRoute GetPathRouteByRoute(string source, string destination)
        {
            return _context.PathRoutes.FirstOrDefault(pr => pr.Source == source && pr.Destination == destination);
        }

        public bool HasAssociatedSchedules(int routeId)
        {
            return _context.Schedules.Any(s => s.RouteId == routeId);
        }

        public bool CreatePathRoute(PathRoute pathRoute)
        {
            if ((_context.PathRoutes.Add(pathRoute)) != null)
            {
                _context.SaveChanges();
                return true;
            }
            return false;
        }

        public void UpdatePathRoute(PathRoute pathRoute)
        {
            _context.PathRoutes.Update(pathRoute);
            _context.SaveChanges();
        }

        public void DeletePathRoute(PathRoute pathRoute)
        {
            _context.PathRoutes.Remove(pathRoute);
            _context.SaveChanges();
        }
    }
}
