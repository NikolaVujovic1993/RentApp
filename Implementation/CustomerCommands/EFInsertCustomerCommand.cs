using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Application.Commands.CustomerCommands;
using Application.DataTransfer.RequestDTO;
using Application.DataTransfer.ResponseDTO;
using Application.Exceptions;
using DomainModels;
using Domain;

namespace Implementation.CustomerCommands
{
	public class EFInsertCustomerCommand : BaseEFCommand, IInsertCustomerCommand
	{
		public EFInsertCustomerCommand(AIContext context) : base(context)
		{
		}

		public CustomerResponseDTO Execute(CustomerRequestDTO request)
		{
			var customer = new Customer();
			
			customer.FirstName = request.FirstName;
			customer.LastName = request.LastName;
			customer.Email = request.Email;
			customer.PhoneNumber = request.PhoneNumber;
			customer.Birthday = request.Birthday;
			AiContext.Customers.Add(customer);
			AiContext.SaveChanges();
			return new CustomerResponseDTO
			{
				Id = customer.Id,
				FirstName = customer.FirstName,
				LastName = customer.LastName,
				Email = customer.Email,
				PhoneNumber = customer.PhoneNumber,
				Birthday = customer.Birthday
			};
		}
	}
}
