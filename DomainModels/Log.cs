using System;
using System.Collections.Generic;
using System.Text;

namespace DomainModels
{
    public class Log : BaseEntity
    {
        public int UserId { get; set; }
        public User User { get; set; }
        public string Action { get; set; }
    }
}
