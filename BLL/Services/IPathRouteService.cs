using DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Services
{
    public interface IPathRouteService
    {
        IEnumerable<PathRoute> GetAllPathRoutes();
        PathRoute GetPathRouteById(int id);
        void CreatePathRoute(PathRoute pathRoute);
        void UpdatePathRoute(PathRoute pathRoute);
        void DeletePathRoute(PathRoute pathRoute);
    }
}
