﻿using BLL.DTOs;
using DAL.Models;
using DAL.Repository;

namespace BLL.Services
{
    public class PathRouteService : IPathRouteService
    {
        private readonly IPathRouteRepository _pathRouteRepository;

        public PathRouteService(IPathRouteRepository pathRouteRepository)
        {
            _pathRouteRepository = pathRouteRepository;
        }
        public ICollection<PathRoute> GetAllPathRoutes()
        {
            return _pathRouteRepository.GetAllPathRoutes();
        }
        public PathRoute GetPathRouteById(int id)
        {
            return _pathRouteRepository.GetPathRouteById(id);
        }
        public bool CreatePathRoute(PathRouteDTO pathRoute)
        {
            // Check if the route already exists
            if (_pathRouteRepository.GetPathRouteByRoute(pathRoute.Source, pathRoute.Destination) != null)
            {
                return false;
            }
            var temp = new PathRoute
            {
                Source = pathRoute.Source,
                Destination = pathRoute.Destination,
                Distance = pathRoute.Distance,
                Price = pathRoute.Price
            };
            if (_pathRouteRepository.CreatePathRoute(temp))
            {
                return true;
            }
            return false;
        }
        public void UpdatePathRoute(PathRoute pathRoute)
        {
            _pathRouteRepository.UpdatePathRoute(pathRoute);
        }
        public void DeletePathRoute(PathRoute pathRoute)
        {
            // Check if the path route has associated schedules
            var hasAssociatedSchedules = _pathRouteRepository.HasAssociatedSchedules(pathRoute.RouteId);

            if (hasAssociatedSchedules)
            {
                return;
            }

            _pathRouteRepository.DeletePathRoute(pathRoute);
        }
    }
}
