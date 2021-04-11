using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace Calendly.Application.Features.Offices.Commands.CreateOffice
{
    public class CreateOfficeCommand : IRequest<CreateOfficeCommandResponse>
    {
        public string Name { get; set; }
        public string ImageUrl { get; internal set; }
    }
}
