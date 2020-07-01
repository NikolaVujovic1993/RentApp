using DomainModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.DataTransfer.ResponseDTO
{
    public class LogResponseDTO
    {
        public string Action { get; set; }
        public int UserId { get; set; }
        public string FirstName { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}
