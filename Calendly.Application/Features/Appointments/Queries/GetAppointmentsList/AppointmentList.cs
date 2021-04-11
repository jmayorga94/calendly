using System;

namespace Calendly.Application.Features.Queries.GetAppointmentList
{
    public class AppointmentList
    {
        public Guid Id { get; set; }
        public string Description { get; set; }
        public Guid OfficeId { get; set; }
        public OfficeDto Office { get; set; }
        public DateTime Date { get; set; }
        public int StartHour { get; set; }
        public int EndHour { get; set; }

    }
}