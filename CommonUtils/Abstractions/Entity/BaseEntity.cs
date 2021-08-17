using System;
using System.Collections.Generic;
using System.Text;

namespace CommonUtils.Abstractions.Entity
{
    public class BaseEntity
    {
        public DateTime CreatedOn { get; protected set; }
        public DateTime ModifiedOn { get; protected set; } = DateTime.UtcNow;
        public Guid Id { get; protected set; }
        public string CreatedBy { get; protected set; }
        public string  ModifiedBy { get; protected set; }
    }
}
