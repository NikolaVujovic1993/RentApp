using System;
using System.Collections.Generic;
using System.Text;
using Application.Commands.VehicleCommands;
using Application.DataTransfer.ResponseDTO;
using Application.Exceptions;
using Domain;
using DomainModels;

namespace Implementation.VehicleCommands
{
	public class EFGetSingleVehicleCommand : BaseEFCommand, IGetSIngleVehicleCommand
	{
		public EFGetSingleVehicleCommand(AIContext context) : base(context)
		{
		}

		public Vehicle Execute(int request)
		{
			var vehicle = AiContext.Vehicles
				.Find(request);
			if (vehicle == null || vehicle.IsDeleted == 1)
				throw new EntityNotFoundException("Vehicle");
			//var brand = AiContext.Brands
			//	.Find(vehicle.BrandId);
			//var vehType = AiContext.VehicleTypes
			//	.Find(vehicle.VehicleTypeId);
			return vehicle;
			//return new VehicleResponseDTO
			//{
			//	Id = vehicle.Id,
			//	Model = vehicle.Model,
			//	CostPerDay = vehicle.CostPerDay,
			//	Color = vehicle.Color,
			//	FuelTankCapacity = vehicle.FuelTankCapacity,
			//	VehicleType = vehType.Name,
			//	VehicleBrand = brand.Name,
			//	Automatic = vehicle.Automatic,
			//	Rented = vehicle.Rented
			//};
		}
	}
}
