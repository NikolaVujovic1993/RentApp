﻿using System;
using System.Collections.Generic;
using System.Text;

namespace DomainModels
{
	public class Location : BaseEntity
	{
		public string Adress { get; set; }
		public double Price { get; set; }
		public ICollection<Rent> Rents { get; set; }
	}
}
