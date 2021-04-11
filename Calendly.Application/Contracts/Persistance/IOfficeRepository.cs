using Calendly.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Calendly.Application.Contracts.Persistance
{
    public interface IOfficeRepository : IAsyncRepository<Office>
    {
        Task<List<Office>> GetOffices(bool includeNotAvailable);
    }
}
