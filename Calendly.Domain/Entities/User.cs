using Calendly.Domain.Commons;
using System;
using System.Collections.Generic;
using System.Text;

namespace Calendly.Domain.Entities
{
    public class User : AuditableEntity
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        
    }
}
