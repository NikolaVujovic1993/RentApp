﻿using Application.Commands.LocationCommands;
using Application.DataTransfer.ResponseDTO;
using Application.Searches;
using Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Implementation.LocationCommands
{
	public class EFGetLocationsCommand : BaseEFCommand, IGetLocationsCommand
	{
		public EFGetLocationsCommand(AIContext context) : base(context)
		{
		}

		public IEnumerable<LocationResponseDTO> Execute(LocationSearch request)
		{
			var keyword = request.Keyword;
			var query = AiContext.Locations
				.Where(x => x.IsDeleted == 0)
				.AsQueryable();
			if (keyword != null)
				query = query
					.Where(x => x.Adress.ToLower().Contains(keyword.ToLower()));
			return query
				.Select(x => new LocationResponseDTO
				{
					Id = x.Id,
					Adress = x.Adress,
					Price = x.Price
				});
		}
	}
}
