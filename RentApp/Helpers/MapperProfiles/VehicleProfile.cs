using AutoMapper;
using DomainModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RentApp.Helpers.MapperProfiles
{
    public class VehicleProfile : Profile
    {
        public VehicleProfile()
        {
            CreateMap<Vehicle, Vehicle>();
            
        }
    }
}
