using System;

namespace Calendly.Application.Features.Offices.Commands.CreateOffice
{
    public class CreateOfficeDto
    {

        public Guid Id { get; set; }
        public string Name { get; set; }
        public string ImageUrl { get; set; }

        public bool IsAvailable { get; set; }
    }
}