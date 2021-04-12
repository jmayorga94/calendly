using Calendly.Application.Contracts.Persistance;
using Calendly.Domain.Entities;
using Moq;
using System;
using System.Collections.Generic;
using System.Text;

namespace Calendly.Application.UnitTests.Mocks
{
    public  class RepositoryMocks
    {
        public static Mock<IAsyncRepository<Appointment>> GetAppointmentRepository()
        {
            var appointmentGuid = Guid.Parse("{f9954c4a-45f9-464f-a12c-6c76b25b2837}");
            var officeId = Guid.Parse("{ae0bb628-9344-40d8-9753-61a9c5d46371}");

            var Office = new Office
            {
                Id = officeId,
                ImageUrl = "http://localhost/image/123-png",
                IsAvailable = false,
                Name = "Headquartes"
            };

            var appointmentList = new List<Appointment>
           {
                new Appointment()
              {
                Id = appointmentGuid,
                Date = DateTime.Now,
                Description = "Appointment at dentist",
                CreationDate = DateTime.Now,
                StartHour = DateTime.Now.Hour,
                EndHour = DateTime.Now.AddHours(2).Hour,
                OfficeId = officeId
            }
        };
           

            var mockAppointmentRepository = new Mock<IAsyncRepository<Appointment>>();
            mockAppointmentRepository.Setup(repo => repo.ListAllAsync()).ReturnsAsync(appointmentList);

            return mockAppointmentRepository;
        }
    }
}
