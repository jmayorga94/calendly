using FluentValidation;
using System.Data;

namespace Calendly.Application.Features.Offices.Commands.CreateOffice
{
    public class CreateOfficeValidator : AbstractValidator<CreateOfficeCommand>
    {
        public CreateOfficeValidator()
        {
            RuleFor(x => x.Name).NotEmpty()
                .WithMessage("{PropertyName} is required")
                .NotNull()
                .MaximumLength(50).WithMessage("{PropertyName} must not exceed 50 characters long");
        }
    }
}