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
        public ICollection<PathRoute> GetAllPathRoutes();
        PathRoute GetPathRouteById(int id);
        bool CreatePathRoute(PathRoute pathRoute);
        void UpdatePathRoute(PathRoute pathRoute);
        void DeletePathRoute(PathRoute pathRoute);
    }
}
