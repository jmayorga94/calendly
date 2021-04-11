using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Calendly.Application.Features.Appointments.Commands.CreateAppointment
{
    public class CreateAppointmentCommandValidator : AbstractValidator<CreateAppointmentCommand>
    {
        public CreateAppointmentCommandValidator()
        {
            RuleFor(x => x.Description)
                  .NotEmpty().WithMessage("{PropertyName} is required")
                  .NotNull()
                  .MaximumLength(50).WithMessage("{PropertyName} must not exceed 50 characters");

            RuleFor(p => p.Date)
                   .NotEmpty().WithMessage("{PropertyName} is required")
                   .NotNull()
                   .Equal(DateTime.Now);

            RuleFor(x => x.StartHour)
                   .NotEmpty().WithMessage("{PropertyName} is required")
                   .NotNull();


            RuleFor(x => x.EndHour)
                   .NotEmpty().WithMessage("{PropertyName} is required")
                   .NotNull();


        }

    }
}
