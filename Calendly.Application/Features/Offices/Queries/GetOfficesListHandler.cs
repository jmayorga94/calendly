using AutoMapper;
using Calendly.Application.Contracts.Persistance;
using Calendly.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Calendly.Application.Features.Offices.Queries
{
    public class GetOfficesListHandler : IRequestHandler<GetOfficesListQuery, List<OfficesList>>
    {
        private readonly IOfficeRepository _officeRepository;
        private readonly IMapper _mapper;
        public GetOfficesListHandler(IOfficeRepository officeRepository, IMapper mapper)
        {
            _officeRepository = officeRepository;
            _mapper = mapper;
        }

        public async Task<List<OfficesList>> Handle(GetOfficesListQuery request, CancellationToken cancellationToken)
        {
            var allOffices = await _officeRepository.GetOffices(request.IncludeNotAvailable);

            return _mapper.Map<List<OfficesList>>(allOffices);
        }
    }
}
