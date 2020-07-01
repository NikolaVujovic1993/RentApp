using System;
using System.Collections.Generic;
using System.Text;

namespace DomainModels
{
	public class RentStatus : BaseEntity
	{
		public string Name { get; set; }
		public ICollection<Rent> Rents { get; set; }
	}
}
