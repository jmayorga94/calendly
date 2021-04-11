using AutoMapper;
using Calendly.Application.Contracts.Infrastructure;
using Calendly.Application.Contracts.Persistance;
using Calendly.Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Calendly.Application.Features.Appointments.Queries.GetAppointmentsExport
{
    public class GetAppointmentExportQueryHandler : IRequestHandler<GetAppointmentExportQuery, ExportAppointmentVm>
    {
        private readonly IAsyncRepository<Appointment> _appointmentRepository;
        private readonly IMapper _mapper;
        private readonly ICvsExporter _exporter;

        public GetAppointmentExportQueryHandler(IAsyncRepository<Appointment> appointmentRepository, IMapper mapper, ICvsExporter exporter)
        {
            _appointmentRepository = appointmentRepository;
            _mapper = mapper;
            _exporter = exporter;
        }

        public async Task<ExportAppointmentVm> Handle(GetAppointmentExportQuery request, CancellationToken cancellationToken)
        {
            var allAppointments = _mapper.Map<List<ExportAppointmentDto>>((await _appointmentRepository.ListAllAsync()).OrderBy(x => x.Date));

            var fileData = _exporter.ExportEventsToCvs(allAppointments);

            var appointmentExportDto = new ExportAppointmentVm()
            {
                Data = fileData,
                AppointmentExportFileName = $"{GetRandomName()}.csv",
                ContentType ="text/csv"

            };

            return appointmentExportDto;

        }

        private Guid GetRandomName()
        {
            var newGuid = Guid.NewGuid();

            return newGuid;
        }

    }
}
