using AutoMapper;
using Calendly.Application.Contracts.Persistance;
using Calendly.Application.Features.Queries.GetAppointmentList;
using Calendly.Application.Profiles;
using Calendly.Application.UnitTests.Mocks;
using Calendly.Domain.Entities;
using Moq;
using System.Threading;
using Xunit;
using Shouldly;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Calendly.Application.UnitTests.Queries
{
    public class GetAppointmentListQueryHandlerTest
    {
        private readonly IMapper _mapper;
        private readonly Mock<IAsyncRepository<Appointment>> _mockAppointmentRepository;

        public GetAppointmentListQueryHandlerTest()
        {
            _mockAppointmentRepository = RepositoryMocks.GetAppointmentRepository();

            var configurationProvider = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile<MappingProfile>();
            });

            _mapper = configurationProvider.CreateMapper();
        }

        [Fact]
        public async Task GetAppointmentsListTest()
        {
            var handler = new GetAppointmentsListQueryHandler(_mapper, _mockAppointmentRepository.Object);
            var result = await handler.Handle(new GetAppointmentListQuery(), CancellationToken.None);

            result.ShouldBeOfType<List<AppointmentList>>();

            result.Count.ShouldBe(1);
        }
    }
}
