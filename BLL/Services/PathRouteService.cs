using BLL.DTOs;
using BLL.Services;
using DAL.Models;
using DAL.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Services
{
    public class PathRouteService : IPathRouteService
    {
        private readonly IPathRouteRepository _pathRouteRepository;

        public PathRouteService(IPathRouteRepository pathRouteRepository)
        {
            _pathRouteRepository = pathRouteRepository;
        }
        public IEnumerable<PathRoute> GetAllPathRoutes()
        {
            return _pathRouteRepository.GetAllPathRoutes();
        }
        public PathRoute GetPathRouteById(int id)
        {
            return _pathRouteRepository.GetPathRouteById(id);
        }
        public void CreatePathRoute(PathRoute pathRoute)
        {
            _pathRouteRepository.CreatePathRoute(pathRoute);
        }
        public void UpdatePathRoute(PathRoute pathRoute)
        {
            _pathRouteRepository.UpdatePathRoute(pathRoute);
        }
        public void DeletePathRoute(PathRoute pathRoute)
        {
            _pathRouteRepository.DeletePathRoute(pathRoute);
        }
    }
}
