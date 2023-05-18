using DAL.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.DTOs
{
    public class PathRouteDTO
    {
        public int RouteId { get; set; }
        public string Source { get; set; }
        public string Destination { get; set; }
        public int Distance { get; set; }

        public static explicit operator PathRoute(PathRouteDTO dto)
        {
            if (dto == null)
                return null;

            return new PathRoute
            {
                RouteId = dto.RouteId,
                Source = dto.Source,
                Destination = dto.Destination,
                Distance = dto.Distance
            };
        }

        public static implicit operator PathRouteDTO(PathRoute pathroute)
        {
            if (pathroute == null)
                return null;

            return new PathRouteDTO
            {
                RouteId = pathroute.RouteId,
                Source = pathroute.Source,
                Destination = pathroute.Destination,
                Distance = pathroute.Distance
            };
        }
    }
}
