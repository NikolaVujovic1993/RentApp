﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Application.DataTransfer.ResponseDTO
{
    public class VehicleResponseDTO
    {
        public int Id { get; set; }
        public string Model { get; set; }
        public double FuelTankCapacity { get; set; }
        public double CostPerDay { get; set; }
        public string VehicleBrand { get; set; }
        public string VehicleType { get; set; }
		public bool Automatic { get; set; }
		public bool Rented { get; set; }
        public string Color { get; set; }

    }
}
