﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Application.Commands.VehicleCommands;
using Application.DataTransfer.ResponseDTO;
using Application.Searches;
using Domain;
using DomainModels;
using Microsoft.EntityFrameworkCore;

namespace Implementation.VehicleCommands
{
    public class EFGetVehiclesCommand : BaseEFCommand, IGetVehiclesCommand
    {
        public EFGetVehiclesCommand(AIContext context) : base(context)
        {
        }

        public IEnumerable<Vehicle> Execute(VehicleSearch request)
        {
            var keyword = request.Keyword;
            var query = AiContext.Vehicles
                .AsQueryable()
                .Where(x => x.IsDeleted == 0);
            if (keyword != null)
                query = query
                    .Where(x => x.Model.ToLower().Contains(keyword.ToLower()));
            return query;
     //           .Select(x => new VehicleResponseDTO
     //           {
     //               Id = x.Id,
     //               Model = x.Model,
     //               CostPerDay = x.CostPerDay,
     //               Color = x.Color,
     //               FuelTankCapacity = x.FuelTankCapacity,
     //               VehicleType = x.VehicleType.Name,
     //               VehicleBrand = x.Brand.Name,
					//Automatic = x.Automatic,
					//Rented = x.Rented
     //           });
        }
    }
}
