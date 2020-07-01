using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Searches
{
    public class LogSearch
    {
        public string Username { get; set; }
        public DateTime? DateFrom { get; set; }
        public DateTime? DateTo { get; set; }
        public string Action { get; set; }
    }
}
