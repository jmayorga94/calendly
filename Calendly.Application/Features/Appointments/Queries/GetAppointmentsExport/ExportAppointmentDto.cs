using System;
using System.Collections.Generic;
using System.Text;

namespace Calendly.Application.Features.Appointments.Queries.GetAppointmentsExport
{
    public class ExportAppointmentDto
    {
        public Guid Id { get; set; }
        public string Description { get; set; }
        public ExportOfficeDto Office { get; set; }
        public DateTime Date { get; set; }
        public int StartHour { get; set; }
        public int EndHour { get; set; }
    }
}
