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

        public IEnumerable<PathRoute> GetAllPathRoutes()
        {
            return _context.PathRoutes.ToList();
        }

        public PathRoute GetPathRouteById(int id)
        {
            return _context.PathRoutes.Find(id);
        }

        public void CreatePathRoute(PathRoute pathRoute)
        {
            _context.PathRoutes.Add(pathRoute);
            _context.SaveChanges();
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
