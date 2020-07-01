using Application.DataTransfer.ResponseDTO.StatusResponseDTO;
using Application.Intefaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Commands.StatusCommands
{
	public interface IGetSingleStatusCommand : ICommand<int, StatusResponseDTO>
	{
	}
}
