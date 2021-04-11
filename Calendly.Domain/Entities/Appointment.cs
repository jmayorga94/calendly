using Calendly.Domain.Commons;
using System;
using System.Collections.Generic;
using System.Text;

namespace Calendly.Domain.Entities
{
    public class Appointment : AuditableEntity
    {
        public Guid Id { get; set; }
        public string Description { get; set; }
        public Guid OfficeId { get; set; }
        public Office Office { get; set; }
        public DateTime Date { get; set; }

        public int StartHour { get; set; }
        public int EndHour { get; set; }

        public DateTime CreationDate { get; set; }
    }
}
