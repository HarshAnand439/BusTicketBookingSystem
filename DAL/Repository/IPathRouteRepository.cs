using DAL.Models;
using Microsoft.EntityFrameworkCore;

namespace DAL.Repository
{
    public interface IPathRouteRepository
    {
        public ICollection<PathRoute> GetAllPathRoutes();
        public PathRoute GetPathRouteById(int id);
        public PathRoute GetPathRouteByRoute(string source, string destination);
        public bool HasAssociatedSchedules(int routeId);
        public bool CreatePathRoute(PathRoute pathRoute);
        public void UpdatePathRoute(PathRoute pathRoute);
        public void DeletePathRoute(PathRoute pathRoute);
    }
}
