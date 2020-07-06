using Application.DataTransfer.ResponseDTO;
using Application.Intefaces;
using DomainModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Commands.VehicleCommands
{
	public interface IGetSIngleVehicleCommand : ICommand<int, Vehicle>
	{
	}
}
