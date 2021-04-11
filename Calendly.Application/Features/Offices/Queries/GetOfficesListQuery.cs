using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace Calendly.Application.Features.Offices.Queries
{
    public class GetOfficesListQuery : IRequest<List<OfficesList>>
    {
        public bool IncludeNotAvailable { get; set; }
    }
}
