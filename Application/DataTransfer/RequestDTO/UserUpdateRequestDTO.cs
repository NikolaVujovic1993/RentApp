﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Application.DataTransfer.RequestDTO
{
	public class UserUpdateRequestDTO
	{
		[Required]
		[MinLength(2, ErrorMessage = "First name must be longer than 2")]
		public string FirstName { get; set; }
		[Required]
		[MinLength(2, ErrorMessage = "Last name must be longer than 2")]
		public string LastName { get; set; }
		[Required]
		[MinLength(5, ErrorMessage = "Username must be longer than 5")]
		public string Username { get; set; }
		
		public int? RoleId { get; set; }
	}
}
