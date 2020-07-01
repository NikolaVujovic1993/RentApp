using Application.DataTransfer;
using Application.DataTransfer.ResponseDTO.RentResponseDTO;
using Application.Intefaces;
using Application.Searches.RentSearches;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Commands.RentCommands
{
	public interface IGetRentsCommand : ICommand<RentSearch, PagedResponseDTO<RentResponseDTO>>
	{
	}
}
