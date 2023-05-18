using DAL.Models;
using Microsoft.EntityFrameworkCore;

namespace DAL.Repository
{
    public interface IPathRouteRepository
    {
        public IEnumerable<PathRoute> GetAllPathRoutes();
        public PathRoute GetPathRouteById(int id);
        public void CreatePathRoute(PathRoute pathRoute);
        public void UpdatePathRoute(PathRoute pathRoute);
        public void DeletePathRoute(PathRoute pathRoute);
    }
}
