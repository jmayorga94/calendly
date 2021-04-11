using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace Calendly.Application.Features.Appointments.Commands.CreateAppointment
{
    public class CreateAppointmentCommand : IRequest<Guid>
    {
        public string Description { get; set; }
        public DateTime Date { get; set; }
        public DateTime StartHour { get; set; }
        public DateTime EndHour { get; set; }
        public Guid OfficeId { get; set; }

        public override string ToString()
        {
            return $"Appointment Description: {Description}; set on {Date};  Starts at : {StartHour}; Ends at : {EndHour}";
        }
    }
}
