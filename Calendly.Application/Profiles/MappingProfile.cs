using AutoMapper;
using Calendly.Application.Features.Appointments.Commands.CreateAppointment;
using Calendly.Application.Features.Appointments.Queries.GetAppointmentsExport;
using Calendly.Application.Features.Offices.Queries;
using Calendly.Application.Features.Queries.GetAppointmentList;
using Calendly.Domain.Entities;

namespace Calendly.Application.Profiles
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Appointment, AppointmentList>().ReverseMap();
            CreateMap<Office, OfficeDto>();
            CreateMap<Office, OfficesList>().ReverseMap();
            CreateMap<CreateAppointmentCommand, Appointment>();
            CreateMap<Appointment, ExportAppointmentDto>();
            CreateMap<Office, ExportOfficeDto>();
        }
    }
}
