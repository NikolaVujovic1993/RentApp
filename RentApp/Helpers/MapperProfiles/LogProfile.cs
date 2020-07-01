using Application.DataTransfer.ResponseDTO;
using AutoMapper;
using DomainModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RentApp.Helpers.MapperProfiles
{
    public class LogProfile : Profile
    {
        public LogProfile()
        {
            CreateMap<Log, LogResponseDTO>()
                .ForMember(dest => dest.FirstName, opt => opt.MapFrom(u => u.User.FirstName));
        }
    }
}
