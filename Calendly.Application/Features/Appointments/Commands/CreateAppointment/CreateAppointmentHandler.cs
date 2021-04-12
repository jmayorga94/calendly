using AutoMapper;
using Calendly.Application.Contracts.Infrastructure;
using Calendly.Application.Contracts.Persistance;
using Calendly.Application.Exceptions;
using Calendly.Application.Models.Mail;
using Calendly.Domain.Entities;
using MediatR;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Calendly.Application.Features.Appointments.Commands.CreateAppointment
{
    public class CreateAppointmentHandler : IRequestHandler<CreateAppointmentCommand, Guid>
    {
        private readonly IAsyncRepository<Appointment> _appointmentRepository;
        private readonly IMapper _mapper;
        private readonly IEmailService _emailService;
        private readonly ILogger<CreateAppointmentHandler> _logger;

        public CreateAppointmentHandler(IAsyncRepository<Appointment> appointmentRepository, IMapper mapper, IEmailService emailService, ILogger<CreateAppointmentHandler> logger)
        {
            _appointmentRepository = appointmentRepository;
            _mapper = mapper;
            _emailService = emailService;
            _logger = logger;
        }
        public async Task<Guid> Handle(CreateAppointmentCommand request, CancellationToken cancellationToken)
        {
            var validator = new CreateAppointmentCommandValidator();

            var validationResult = await validator.ValidateAsync(request);

            if (validationResult.Errors.Count > 0)
            {
                throw new Exceptions.ValidationException(validationResult);
            }

            var appointment = _mapper.Map<Appointment>(request);

            await _appointmentRepository.AddAsync(appointment);


            var email = new Email()
            {
                To = "javi.mayorga1994@outlook.com",
                Body = $"An appointment has been created: {request} ",
                Subject = "An new appointment was created"
            };

            try
            {
                await _emailService.SendEmail(email);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Mailing about appointment {appointment.Id} failed due to an error with the mail service: {ex.Message}");
            }

            return appointment.Id;
        }
    }
}
