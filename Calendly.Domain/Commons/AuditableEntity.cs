using System;
using System.Collections.Generic;
using System.Text;

namespace Calendly.Domain.Commons
{
    public class AuditableEntity
    {
        public string CreatedBy { get; set; }
        public DateTime CreatedDate { get; set; }
        public string LastModified { get; set; }
        public DateTime? LastModifiedDate { get; set; }
    }
}
