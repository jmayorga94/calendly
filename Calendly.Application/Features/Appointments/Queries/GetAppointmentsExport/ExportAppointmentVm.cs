using System;

namespace Calendly.Application.Features.Appointments.Queries.GetAppointmentsExport
{
    public class ExportAppointmentVm
    {
        public byte[] Data { get; set; }
        public string ContentType { get; set; }
        public string AppointmentExportFileName { get; set; }

    }
}