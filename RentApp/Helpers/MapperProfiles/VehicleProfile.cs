using Application.DataTransfer.ResponseDTO;
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
            CreateMap<Vehicle, VehicleResponseDTO>()
                 .ForMember(dest => dest.VehicleBrand, opt => opt.MapFrom(b => b.Brand.Name))
                 .ForMember(dest => dest.VehicleType, opt => opt.MapFrom(t => t.VehicleType.Name));

        }
    }
}
