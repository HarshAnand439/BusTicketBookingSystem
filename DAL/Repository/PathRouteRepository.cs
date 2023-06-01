using DAL.Data;
using DAL.Models;

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
