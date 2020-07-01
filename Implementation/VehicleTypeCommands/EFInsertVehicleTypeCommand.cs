using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Application.Commands.VehicleTypeCommands;
using Application.DataTransfer.RequestDTO;
using Application.DataTransfer.ResponseDTO;
using Application.Exceptions;
using DomainModels;
using Domain;

namespace Implementation.VehicleTypeCommands
{
    public class EFInsertVehicleTypeCommand : BaseEFCommand, IInsertVehicleTypeCommand
    {
        public EFInsertVehicleTypeCommand(AIContext context) : base(context)
        {
        }

        public VehicleTypeResponseDTO Execute(VehicleTypeRequestDTO request)
        {
            var vehType = new VehicleType();
            var existingVehType = AiContext.VehicleTypes
                .Where(x => x.Name == request.Name)
                .Where(x => x.IsDeleted == 0)
                .FirstOrDefault();
            if (existingVehType != null)
                throw new EntityExistsException("Vehicle type");
            vehType.Name = request.Name;
            AiContext.VehicleTypes
                .Add(vehType);
            AiContext.SaveChanges();
            return new VehicleTypeResponseDTO
            {
                Id = vehType.Id,
                Name = vehType.Name
            };
        }
    }
}
