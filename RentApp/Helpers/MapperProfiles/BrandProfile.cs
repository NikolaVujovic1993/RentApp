using Application.DataTransfer.ResponseDTO;
using AutoMapper;
using DomainModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RentApp.Helpers.MapperProfiles
{
    public class BrandProfile : Profile
    {
        public BrandProfile()
        {
            CreateMap<Brand, BrandResponseDTO>();
            CreateMap<BrandResponseDTO, Brand>();
        }
    }
}
