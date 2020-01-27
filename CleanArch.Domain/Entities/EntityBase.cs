using System;
using System.Collections.Generic;
using System.Text;

namespace CleanArch.Domain.Entities
{
    public abstract class EntityBase
    {
        public long Id { get; set; }
        public string CreatedBy { get; set; }
        public DateTime CreatedDt { get; set; }
        public string UpdatedBy { get; set; }
        public DateTime UpdatedDt { get; set; }
        public bool IsDeleted { get; set; }
    }
}
