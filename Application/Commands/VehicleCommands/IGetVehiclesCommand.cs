using Application.DataTransfer.ResponseDTO;
using Application.Intefaces;
using Application.Searches;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Commands.VehicleCommands
{
    public interface IGetVehiclesCommand : ICommand<VehicleSearch, IEnumerable<VehicleResponseDTO>>
    {
    }
}
