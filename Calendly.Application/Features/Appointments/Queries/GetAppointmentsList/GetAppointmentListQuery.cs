using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace Calendly.Application.Features.Queries.GetAppointmentList
{
    public class GetAppointmentListQuery : IRequest<List<AppointmentList>>
    {

    }
}
