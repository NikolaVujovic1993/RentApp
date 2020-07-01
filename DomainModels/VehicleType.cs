using System;
using System.Collections.Generic;
using System.Text;

namespace DomainModels
{
    public class VehicleType : BaseEntity
    {
        public string Name { get; set; }
        public ICollection<Vehicle> Vehicles { get; set; }
    }
}
