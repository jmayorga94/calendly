using Calendly.Domain.Commons;
using System;
using System.Collections.Generic;
using System.Text;

namespace Calendly.Domain.Entities
{
    public class Office : AuditableEntity
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string ImageUrl { get; set; }
        public bool IsAvailable { get; set; }
        public ICollection<Appointment> Appoitments { get; set; }

    }
}
