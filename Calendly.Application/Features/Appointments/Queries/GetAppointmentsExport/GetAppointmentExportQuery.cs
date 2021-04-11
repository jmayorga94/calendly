using MediatR;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Text;

namespace Calendly.Application.Features.Appointments.Queries.GetAppointmentsExport
{
    public class GetAppointmentExportQuery : IRequest<ExportAppointmentVm>
    {

    }
}
