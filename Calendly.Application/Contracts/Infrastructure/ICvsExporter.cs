using Calendly.Application.Features.Appointments.Queries.GetAppointmentsExport;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Calendly.Application.Contracts.Infrastructure
{
    public interface ICvsExporter
    {
        byte[] ExportEventsToCvs(List<ExportAppointmentDto> allAppointments);
    }
}
