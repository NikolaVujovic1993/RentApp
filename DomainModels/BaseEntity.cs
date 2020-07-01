using System;
using System.Collections.Generic;
using System.Text;

namespace DomainModels
{
    public class BaseEntity
    {
        public int Id { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime? ModifiedAt { get; set; }
        public int? IsDeleted { get; set; }
    }
}
