using Calendly.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Calendly.Application.Contracts.Persistance
{
    public interface IAppointmentRepository : IAsyncRepository<Appointment>
    {

    }
}
