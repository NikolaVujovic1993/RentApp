﻿using Application.DataTransfer.RequestDTO;
using Application.DataTransfer.ResponseDTO;
using Application.Intefaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Commands.CustomerCommands
{
	public interface IInsertCustomerCommand : ICommand<CustomerRequestDTO, CustomerResponseDTO>
	{
	}
}
