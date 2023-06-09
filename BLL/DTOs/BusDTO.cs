﻿using DAL.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.DTOs
{
    public class BusDTO
    {
        public string BusNumber { get; set; }
        public int Capacity { get; set; }

        public static implicit operator BusDTO(Bus bus)
        {
            return new BusDTO
            {
                BusNumber = bus.BusNumber,
                Capacity = bus.Capacity
            };
        }

        public static explicit operator Bus(BusDTO dto)
        {
            return new Bus
            {
                BusNumber = dto.BusNumber,
                Capacity = dto.Capacity
            };
        }
    }
}
