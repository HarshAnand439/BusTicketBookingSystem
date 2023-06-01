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
        public string Source { get; set; }
        public string Destination { get; set; }
        public int Distance { get; set; }
        public int Price { get; set; }

        public static explicit operator PathRoute(PathRouteDTO dto)
        {
            if (dto == null)
                return null;

            return new PathRoute
            {
                Source = dto.Source,
                Destination = dto.Destination,
                Distance = dto.Distance,
                Price = dto.Price
            };
        }

        public static implicit operator PathRouteDTO(PathRoute pathroute)
        {
            if (pathroute == null)
                return null;

            return new PathRouteDTO
            {
                Source = pathroute.Source,
                Destination = pathroute.Destination,
                Distance = pathroute.Distance,
                Price = pathroute.Price
            };
        }
    }
}
