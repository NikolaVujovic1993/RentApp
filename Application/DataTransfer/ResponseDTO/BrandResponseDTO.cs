using DomainModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.DataTransfer.ResponseDTO
{
    public class BrandResponseDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public IEnumerable<BrandVehicleResponseDTO> Vehicles { get; set; }
    }
}
