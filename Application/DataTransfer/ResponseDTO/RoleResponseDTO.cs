using System;
using System.Collections.Generic;
using System.Text;

namespace Application.DataTransfer.ResponseDTO
{
	public class RoleResponseDTO
	{
		public int Id { get; set; }
		public string Name { get; set; }
		public IEnumerable<UserResponseDTO> Users { get; set; }
	}
}
