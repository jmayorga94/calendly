using AutoMapper;
using Calendly.Application.Contracts.Persistance;
using Calendly.Domain.Entities;
using MediatR;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Calendly.Application.Features.Queries.GetAppointmentList
{
    public class GetAppointmentsListQueryHandler : IRequestHandler<GetAppointmentListQuery, List<AppointmentList>>
    {
        private readonly IAsyncRepository<Appointment> _appointmentRepository;
        private readonly IAsyncRepository<Office> _officeRepository;
        private readonly IMapper _mapper;

        public GetAppointmentsListQueryHandler(IMapper mapper, IAsyncRepository<Appointment> appointmentRepository)
        {
            _mapper = mapper;
            _appointmentRepository = appointmentRepository;

        }
        public async Task<List<AppointmentList>> Handle(GetAppointmentListQuery request, CancellationToken cancellationToken)
        {
            var allAppointments = (await _appointmentRepository.ListAllAsync()).OrderBy(x => x.Date);

            return _mapper.Map<List<AppointmentList>>(allAppointments);

        }
    }
}
